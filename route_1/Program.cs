/*1 задание ---------------------------------------------------------------------------------------------------------------------------------------

*/

var testCaseCount = int.Parse(Console.ReadLine());
for (var i = 0; i < testCaseCount; i++)
{
    var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    Console.WriteLine(collection.Sum());
}

/* 2 задание---------------------------------------------------------------------------------------------------------------------------------

*/

int _countDataSet = int.Parse(Console.ReadLine());
int _countProducts = 0;
int indexStop = 0;
int sum = 0;
int prew = 0;
for (int i = 0; i < _countDataSet; i++)
{
    _countProducts = int.Parse(Console.ReadLine());
    int[] collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    Array.Sort(collection);
    prew = collection[0];
    indexStop = 0;
    sum = 0;
    for (int j = 0; j < _countProducts; j++)
    {
        if (prew != collection[j] && j > 0)
        {
            sum += prew * (j - indexStop - ((j - indexStop) / 3));
            indexStop = j;
        }
        else if (prew != collection[j] && j == 0)

        {
            sum += prew;
        }
        if (j + 1 == _countProducts)
        {
            sum += collection[j] * (j + 1 - indexStop - ((j + 1 - indexStop) / 3));
            indexStop = j;
        }
        prew = collection[j];

    }
    Console.WriteLine(sum);

}


/* 3 Задание----------------------------------------------------------------------------------------------------------------------------------

*/
byte _countDataSet = byte.Parse(Console.ReadLine());
byte _countProgrammers = 0;
byte[] experienceProgrammers;
byte[] differentExperienceProgrammers;
//byte[] programmersNotCount;
byte differeceValue = 0;
byte indexProgrammerTwo = 0;
byte countPainrs = 0;
bool executing = true;
byte nowProgrammer = 0;

for (byte i = 0; i < _countDataSet; i++)
{
    _countProgrammers = byte.Parse(Console.ReadLine());
    experienceProgrammers = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();
    differentExperienceProgrammers = new byte[experienceProgrammers.Length];
    Array.Copy(experienceProgrammers, differentExperienceProgrammers, experienceProgrammers.Length);


    for (byte j = 0; j < experienceProgrammers.Length; j++)
    {
        differeceValue = byte.MaxValue;
        nowProgrammer = experienceProgrammers[j];
        if (nowProgrammer == 0)
            continue;

        for (byte h = (byte)(j + 1); h < experienceProgrammers.Length; h++)
        {
            if (experienceProgrammers[h] == 0)
                continue;
            if (Math.Abs(nowProgrammer - experienceProgrammers[h]) < differeceValue)
            {
                differeceValue = (byte)Math.Abs(nowProgrammer - experienceProgrammers[h]);
                indexProgrammerTwo = h;
            }
        }

        Console.WriteLine(string.Format("{0} {1}", j + 1, indexProgrammerTwo + 1));

        experienceProgrammers[j] = 0;
        experienceProgrammers[indexProgrammerTwo] = 0;
    }


}




/*4 задание -----------------------------------------------------------------------------------------------------------------------------

*/

byte _countDataSet = byte.Parse(Console.ReadLine());
byte[] _countRowsColumns;
byte[,] _tableValues;
byte[,] _tableValuesResult;
byte _countClicks = 0;
byte[] _clicks;
byte[] _inputValues;
Dictionary<byte, byte> keyValuePairsSorting = new Dictionary<byte, byte>();
byte[] _tempRowForSorting;
sbyte index = 0;
byte[][,] _resultArrays = new byte[_countDataSet][,];

Console.ReadLine();
for (byte i = 0; i < _countDataSet; i++)
{
    _countRowsColumns = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();
    _tableValues = new byte[_countRowsColumns[0], _countRowsColumns[1]];
    _tableValuesResult = new byte[_countRowsColumns[0], _countRowsColumns[1]];
    _tempRowForSorting = new byte[_countRowsColumns[1]];

    for (byte j = 0; j < _tableValues.GetLength(0); j++)
    {
        _inputValues = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();

        for (byte h = 0; h < _inputValues.Length; h++)
        {
            _tableValues[j, h] = _inputValues[h];
        }
    }

    _countClicks = byte.Parse(Console.ReadLine()); // считаю что обработка данного условия задачи вообще не нужная вещь
    _clicks = Console.ReadLine().Split(' ').Select(it => (byte)(byte.Parse(it) - 1)).ToArray();



    for (byte j = 0; j < _clicks.Length; j++)
    {
        keyValuePairsSorting.Clear();
        for (byte h = 0; h < _tableValues.GetLength(0); h++)
        {
            keyValuePairsSorting.Add((byte)(h + 1), _tableValues[h, _clicks[j]]);
        }

        keyValuePairsSorting = keyValuePairsSorting.OrderBy(it => it.Value).ToDictionary(it => it.Key, it => it.Value);

        index = -1;
        foreach (byte item in keyValuePairsSorting.Keys)
        {
            index++;
            for (byte h = 0; h < _tableValues.GetLength(1); h++)
            {

                //_tempRowForSorting[h] = _tableValues[index, h];
                _tableValuesResult[index, h] = _tableValues[item - 1, h];
                //_tableValues[item - 1, index] = _tempRowForSorting[h];
            }
        }
        _tableValues = _tableValuesResult.Clone() as byte[,];
    }
    _resultArrays[i] = _tableValuesResult.Clone() as byte[,];
    Console.ReadLine();


    for (byte j = 0; j < _tableValues.GetLength(0); j++)
    {

        for (byte h = 0; h < _tableValues.GetLength(1); h++)
        {

            if (h + 1 == _tableValues.GetLength(1))
            {
                Console.WriteLine(_tableValues[j, h]);
                break;
            }
            Console.Write(_tableValues[j, h] + " ");
        }
    }
  
}


/* 5 задание необходимо доработать-------------------------------------------------------------------------------------

*/

int line;
int count;
string sum = "YES";
line = Int32.Parse(Console.ReadLine());
string[] exit = new string[line];
for (int i = 0; i < line; i++)
{
    sum = "YES";
    count = Int32.Parse(Console.ReadLine());
    int[] subs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int[] unicArr = subs.Distinct().ToArray();
    for (int j = 0; j < unicArr.Length; j++)
    {
        int[] indexes = subs.Select((a, i) => (a, i)).Where(x => x.a == unicArr[j]).Select(x => x.i).ToArray();
        for (int t = 0; t < indexes.Length - 1; t++)
        {
            if (indexes[t + 1] > indexes[t] + 1)
                sum = "NO";
        }
    }
}
for (int i = 0; i < line; i++)
{
    Console.WriteLine(exit[i]);
}


/* Задание 6 -----------------------------------------------------------------------------------------------------------------------------

*/

byte _countDataSet = byte.Parse(Console.ReadLine());
        ushort _countTimePairs = 0;
        string[] _inputValueString = new string[2];
        DateTime[,] _inputValueDateTime;
        List<Int64> _tempList = new List<Int64>();
        Dictionary<DateTime, DateTime> _keyValuePairs = new Dictionary<DateTime, DateTime>();
        DateTime _dateTimeOne;
        DateTime _dateTimeTwo;
        KeyValuePair<DateTime, DateTime> lastItem;

        for (byte i = 0; i < _countDataSet; i++)
        {
            _countTimePairs = Convert.ToUInt16(Console.ReadLine());
            _inputValueDateTime = new DateTime[_countTimePairs, 2];



            if (!InputData())
                continue;


            if (!CheckFiltered())
                continue;

            Console.WriteLine("YES");
        }

        bool InputData()
        {
            _keyValuePairs.Clear();
            for (ushort j = 0; j < _countTimePairs; j++)
            {
                _inputValueString = Console.ReadLine().Split('-').ToArray();
                try
                {
                    _dateTimeOne = Convert.ToDateTime(_inputValueString[0]);
                    _dateTimeTwo = Convert.ToDateTime(_inputValueString[1]);
                    if (_dateTimeOne > _dateTimeTwo)
                    {
                        Ending((ushort)(j + 1));
                        return false;
                    }
                    _keyValuePairs.Add(_dateTimeOne, _dateTimeTwo);
                }
                catch (Exception ex)
                {
                    Ending((ushort)(j + 1));
                    return false;
                }

            }
            _keyValuePairs = _keyValuePairs.OrderBy(it => it.Key).ToDictionary(it => it.Key, it => it.Value);
            return true;
        }

        bool CheckFiltered()
        {
            lastItem = _keyValuePairs.First();
            foreach (KeyValuePair<DateTime, DateTime> item in _keyValuePairs)
            {
                if (lastItem.Value > item.Value
                    || (lastItem.Value >= item.Key && lastItem.Key != item.Key)
                    || (lastItem.Value == item.Value && lastItem.Key != item.Key))
                {
                    Ending(_countTimePairs);
                    return false;
                }
                lastItem = item;
            }

            return true;
        }

        void Ending(ushort index)
        {
            for (ushort i = index; i < _countTimePairs; i++)
                Console.ReadLine();
            Console.WriteLine("NO");
        }
/*Задание 7 --------------------------------------------------------------------------------------------------------------------------------------

*/

int[] _inputSettings = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
Dictionary<int, int> _keyValuePairs = new Dictionary<int, int>();
List<int>[] _friends = new List<int>[_inputSettings[0]];
for (int i = 0; i < _friends.Length; i++)
{
    _friends[i] = new List<int>() { i };
}
List<int> _possibleFriends = new List<int>();
int[] _countFriends;
int[] _countFriendsHelp;
int[] _inputPairsFritnds = new int[2];
int[] _possibleFriendsArray;

int _tempMax = 0;
bool _answer = true;

int index = 0;
int s = 0;
int t = 0;
for (int i = 0; i < _inputSettings[1]; i++)
{
    _inputPairsFritnds = Console.ReadLine().Split(' ').Select(it => (int)(int.Parse(it) - 1)).ToArray();
    _friends[_inputPairsFritnds[0]].Add(_inputPairsFritnds[1]);
    _friends[_inputPairsFritnds[1]].Add(_inputPairsFritnds[0]);
}
for (int i = 0; i < _friends.Length; i++)
{
    _answer = true;
    _possibleFriends.Clear();
    index = 0;
    s = 0;
    for (; s < _friends[i].Count; s++)
    {
        t = 0;
        for (; t < _friends[_friends[i][s]].Count; t++)
        {
            _possibleFriends.Add(_friends[_friends[i][s]][t]);
        }
    }

    _possibleFriends.Sort();
    _countFriends = _possibleFriends.ToArray<int>();


    _possibleFriendsArray = _possibleFriends.Except(_friends[i]).ToArray<int>();
    _countFriendsHelp = new int[_possibleFriendsArray.Length];
    if (_countFriendsHelp.Length == 0)
    {
        Console.WriteLine("0");
        continue;
    }
    s = 0;
    for (; s < _possibleFriendsArray.Length; s++)
    {
        for (; index < _countFriends.Length; index++)
        {
            if (_possibleFriendsArray[s] == _countFriends[index])
            {
                _countFriendsHelp[s]++;
            }
            else if (_possibleFriendsArray[s] < _countFriends[index])
                break;
        }
    }

    _tempMax = _countFriendsHelp.Max();

    _answer = false;
    s = 0;
    for (; s < _possibleFriendsArray.Length; s++)
    {
        if (_countFriendsHelp[s] != _tempMax)
        {
            continue;
        }
        Console.Write(_possibleFriendsArray[s] + 1 + " ");
        _answer = true;

    }
    if (!_answer)
    {
        Console.WriteLine("0");
    }
    else
    {
        Console.WriteLine();
    }

}


/*Задание 11 --------------------------------------------------------------------------------------------------------------------------------------
select distinct orders.user_id id, users.name
from orders 
left join users
on orders.user_id = users.id
order by name,id
*/


Console.ReadLine();


