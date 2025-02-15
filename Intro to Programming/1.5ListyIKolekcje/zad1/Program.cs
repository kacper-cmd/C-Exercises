using System.Collections;

var collection = new ArrayList();

collection.Add(true);
collection.Add(false);
collection.Add(new DateTime(2020, 3, 1));
collection.Add(new DateTime(2022, 4, 3));
collection.Add("aaa");
collection.Add("bbb");
collection.Add(1);
collection.Add(2);
collection.Add((decimal)5);
collection.Add((decimal)12);

collection.OfType<DateTime>().ToList().ForEach(x => Console.Write($"{x.ToString("dd'.'MM'.'yyyy")} "));



