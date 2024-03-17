namespace AddressApi.Map
{
    public interface IAddressMap
    {
        Dictionary<string, string> Get(int communal_code, int street_code);
        List<Dictionary<string, string>> Search(string query);
    }

    public class InMemoryAdressMap : IAddressMap
    {
        private Dictionary<Tuple<int, int>, Dictionary<string, string>> address_map =
            new MapBuilder().BuildMap();

        public Dictionary<String, string> Get(int communal_code, int street_code)
        {
            return address_map[new Tuple<int, int>(communal_code, street_code)];
        }

        public List<Dictionary<string, string>> Search(string query)
        {
            var result = new List<Dictionary<string, string>>();
            foreach (var (key, value) in address_map)
            {
                if (value.Keys.Contains("Aktvej") && value["Aktvej"].StartsWith(query))
                {
                    // Console.WriteLine($"appending {value["Aktvej"]} for query {query}");
                    result.Add(value);
                }
            }
            Console.WriteLine($"Length in model {result.Count()}");
            return result;
        }
    }

    public class MapBuilder
    {
        public Dictionary<Tuple<int, int>, Dictionary<string, string>> BuildMap()
        {
            var code_map = new Dictionary<string, DataPoint>()
            {
                {
                    "001",
                    new DataPoint()
                    {
                        Name = "Aktvej",
                        Index = 71,
                        Length = 40
                    }
                },
                {
                    "002",
                    new DataPoint()
                    {
                        Name = "Bolig",
                        Index = 33,
                        Length = 33
                    }
                },
                {
                    "003",
                    new DataPoint()
                    {
                        Name = "Bynavn",
                        Index = 33,
                        Length = 33
                    }
                },
                {
                    "004",
                    new DataPoint()
                    {
                        Name = "Postdist",
                        Index = 32,
                        Length = 4
                    }
                },
                {
                    "005",
                    new DataPoint()
                    {
                        Name = "Notatvej",
                        Index = 1,
                        Length = 4
                    }
                },
                {
                    "006",
                    new DataPoint()
                    {
                        Name = "Byfornydist",
                        Index = 38,
                        Length = 30
                    }
                },
                {
                    "007",
                    new DataPoint()
                    {
                        Name = "Divdist",
                        Index = 38,
                        Length = 30
                    }
                },
                {
                    "008",
                    new DataPoint()
                    {
                        Name = "Evakuerdist",
                        Index = 33,
                        Length = 30
                    }
                },
                {
                    "009",
                    new DataPoint()
                    {
                        Name = "Kirkedist",
                        Index = 34,
                        Length = 30
                    }
                },
                {
                    "010",
                    new DataPoint()
                    {
                        Name = "Skoledist",
                        Index = 34,
                        Length = 30
                    }
                },
                {
                    "011",
                    new DataPoint()
                    {
                        Name = "Befolkdist",
                        Index = 37,
                        Length = 30
                    }
                },
                {
                    "012",
                    new DataPoint()
                    {
                        Name = "Socialdist",
                        Index = 34,
                        Length = 30
                    }
                },
                {
                    "013",
                    new DataPoint()
                    {
                        Name = "Sognedist",
                        Index = 36,
                        Length = 20
                    }
                },
                {
                    "014",
                    new DataPoint()
                    {
                        Name = "Valgdist",
                        Index = 34,
                        Length = 30
                    }
                },
                {
                    "015",
                    new DataPoint()
                    {
                        Name = "Varmedist",
                        Index = 36,
                        Length = 30
                    }
                },
            };

            var reader = new StreamReader("./A370715 2.txt");
            var data = new Dictionary<Tuple<int, int>, Dictionary<string, string>>();

            var line = reader.ReadLine();
            while (line != null)
            {
                var code = line.Substring(0, 3);
                var communal_code = Int32.Parse(line.Substring(3, 4));
                var street_code = Int32.Parse(line.Substring(7, 4));
                if (code != "000" && code != "999")
                {
                    var meta = code_map[code];
                    var end_index = Math.Min(meta.Length, line.Length - meta.Index);
                    var value = line.Substring(meta.Index, end_index);
                    var key = new Tuple<int, int>(communal_code, street_code);
                    if (!data.Keys.Contains(key))
                    {
                        data[key] = new Dictionary<string, string>();
                    }
                    data[key][meta.Name] = value.Trim();
                }

                line = reader.ReadLine();
            }
            return data;
        }
    }

    struct DataPoint
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }

        public DataPoint(string name, int index, int length)
        {
            Name = name;
            Index = index;
            Length = length;
        }
    }
}
