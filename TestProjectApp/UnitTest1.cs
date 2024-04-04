using System.Text.RegularExpressions;

namespace TestProjectApp
{
    public class Tests
    {
        public List<string> check1 = new List<string>();
        public List<string> check2 = new List<string>();
        [SetUp]
        public void Setup()
        {
            check1 = TextFormatter.ReadLinesFromFile("C:\\Users\\LSDGod\\source\\repos\\TestProjectApp\\TestProjectApp\\Receipt_006.txt");
            check2 = TextFormatter.ReadLinesFromFile("C:\\Users\\LSDGod\\source\\repos\\TestProjectApp\\TestProjectApp\\Receipt_007.txt");
        }

        [Test]
        public void Test_DepartureDate_Check1()
        {
            string datePattern = @"\d\s\d\s\.\s\d\s\d\s\.\s\d\s\d\s\d\s\d";
            string line = TextFormatter.GetDepartureDate(check1);
            if (Regex.IsMatch(line, datePattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Дата поездки не найдена или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_DepartureDate_Check2()
        {
            string datePattern = @"\d\s\d\s\.\s\d\s\d\s\.\s\d\s\d\s\d\s\d";
            string line = TextFormatter.GetDepartureDate(check2);
            if (Regex.IsMatch(line, datePattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Дата поездки не найдена или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_DepartureStation_Check1()
        {
            string expectedDepartureStation = "Екатеринбург-Пассажирский";
            string actualDepartureStation = TextFormatter.GetDepartureStation(check1);
            Assert.AreEqual(expectedDepartureStation, actualDepartureStation);
        }
        [Test]
        public void Test_DepartureStation_Check2()
        {
            string expectedDepartureStation = "Московский вокзал";
            string actualDepartureStation = TextFormatter.GetDepartureStation(check2);
            Assert.AreEqual(expectedDepartureStation, actualDepartureStation);
        }
        [Test]
        public void Test_DestinationStation_Check1()
        {
            string expectedDepartureStation = "Нижний Тагил";
            string actualDepartureStation = TextFormatter.GetDestinationStation(check1);
            Assert.AreEqual(expectedDepartureStation, actualDepartureStation);
        }
        [Test]
        public void Test_DestinationStation_Check2()
        {
            string expectedDepartureStation = "Пл. 75 км";
            string actualDepartureStation = TextFormatter.GetDestinationStation(check2);
            Assert.AreEqual(expectedDepartureStation, actualDepartureStation);
        }
        [Test]
        public void Test_TicketNumber_Check1()
        {
            string numberPattern = @"\d\d\d\d\d";
            string line = TextFormatter.GetTicketNumber(check1);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Номер билета не найден или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_TicketNumber_Check2()
        {
            string numberPattern = @"\d\d\d\d\d";
            string line = TextFormatter.GetTicketNumber(check2);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Номер билета не найден или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_SystemNumber_Check1()
        {
            string numberPattern = @"\d\d\d\d\d\d\d\d\d\d\d\d\d";
            string line = TextFormatter.GetSystemNumber(check1);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Системный номер билета не найден или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_SystemNumber_Check2()
        {
            string numberPattern = @"\d\d\d\d\d\d\d\d\d\d\d\d\d";
            string line = TextFormatter.GetSystemNumber(check2);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Системный номер билета не найден или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_TransportDetails_Chek1()
        {
            string expectedTransportDetails = "Перевозка Разовый Полный -> П";
            string actualTransportDetails = TextFormatter.GetTransportDetails(check1);
            Assert.AreEqual(expectedTransportDetails, actualTransportDetails);
        }
        [Test]
        public void Test_TransportDetails_Chek2()
        {
            string expectedTransportDetails = "Перевозка Разовый Полный -> П";
            string actualTransportDetails = TextFormatter.GetTransportDetails(check2);
            Assert.AreEqual(expectedTransportDetails, actualTransportDetails);
        }
        [Test]
        public void Test_TariffCost_Chek1()
        {
            string numberPattern = @"\d\d\.\d\d";
            string line = TextFormatter.GetTariffCost(check1); 
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Стоимость билета не найдена или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_TariffCost_Chek2()
        {
            string numberPattern = @"\d\d\.\d\d";
            string line = TextFormatter.GetTariffCost(check2);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Стоимость билета не найдена или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_TotalCost_Check1()
        {
            string numberPattern = @"\d\d\,\d\d";
            string line = TextFormatter.GetTotalCost(check1);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Стоимость билета не найдена или имеет неправильный формат.");
            }
        }
        [Test]
        public void Test_TotalCost_Check2()
        {
            string numberPattern = @"\d\d\,\d\d";
            string line = TextFormatter.GetTotalCost(check2);
            if (Regex.IsMatch(line, numberPattern))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Стоимость билета не найдена или имеет неправильный формат.");
            }
        }
    }

    public class TextFormatter
    {
        public static List<string> ReadLinesFromFile(string filePath)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != " " && line != "\n" && line != "")
                    {
                        lines.Add(line); // C:\Users\LSDGod\Downloads\promit\Receipt_006.txt
                    }
                }
            }
            return lines;
        }
        public static string GetDepartureDate(List<string> lines)
        {
            string result;
            result = lines[2].Trim(' ', 'н', 'а', '-', '>', 'П');
            return result;
        }
        public static string GetDepartureStation(List<string> lines)
        {
            string result = lines[3].Trim(' ').TrimStart('о', 'т').Trim(' ');
            return result;
        }
        public static string GetDestinationStation(List<string> lines)
        {
            string result = lines[4].Trim(' ').TrimStart('д', 'о').Trim(' ');
            return result;
        }
        public static string GetTicketNumber(List<string> lines)
        {
            string[] parts = lines[5].Split(new string[] { "   " }, StringSplitOptions.None);
            string result = parts[0].Trim(' ').TrimStart('Б', 'и', 'л', 'е', 'т', ' ', 'N', ':').Trim(' ');
            return result;
        }
        public static string GetSystemNumber(List<string> lines)
        {
            string[] parts = lines[5].Split(new string[] { "   " }, StringSplitOptions.None);
            string result = parts[1].Trim(' ').TrimStart('с', 'и', 'с', 'т', '.', 'N', ':').Trim(' ');
            return result;
        }
        public static string GetTransportDetails(List<string> lines)
        {
            string[] parts = lines[6].Split(new string[] { "           " }, StringSplitOptions.None);
            string result = parts[0];
            return result;
        }
        public static string GetTariffCost(List<string> lines)
        {
            string[] parts = lines[7].Split(new string[] { "            " }, StringSplitOptions.None);
            string result = parts[1].Trim('=');
            return result;
        }
        public static string GetTotalCost(List<string> lines)
        {
            string[] parts = lines[8].Split(new string[] { " " }, StringSplitOptions.None);
            string result = parts[1];
            return result;
        }
    }

}