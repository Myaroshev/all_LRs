using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;




namespace PL_lab4
{

    [Serializable]
    internal class Class1<T>
    {


        //задание_№1
        public static bool isElements(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }





        //задание_№2
        public static void remove_items<T>(LinkedList<T> list, T value, string direction)
        {
            if (direction.ToLower() == "start")
            {
                LinkedListNode<T> node = list.First;
                while (node != null)
                {
                    if (node.Value.Equals(value))
                    {
                        list.Remove(node);
                        return;
                    }
                    node = node.Next;
                }

                Console.WriteLine("Элемент не найден в списке");
            }
            else if (direction.ToLower() == "end")
            {
                LinkedListNode<T> node = list.Last;
                while (node != null)
                {
                    if (node.Value.Equals(value))
                    {
                        list.Remove(node);
                        Console.WriteLine($"Элемент {value} удален из списка");
                        return;
                    }
                    node = node.Previous;
                }

                Console.WriteLine("Элемент не найден в списке");
            }
            else
            {
                Console.WriteLine("Используйте 'start' или 'end'");
            }
        }









        //задание_№3
        public static HashSet<T> all_likes<T>(HashSet<T> musics, HashSet<T> meloman1, HashSet<T> meloman2, HashSet<T> meloman3)
        {
            HashSet<T> all_music_liked = new HashSet<T>(musics); //в этом множестве находятся ВСЕ произведения

            //пересечение
            //например: есть Произведение_1, Произведение_2, Произведение_3, Произведение_4, Произведение_5
            //и у второго - Произведение_1, Произведение_2, Произведение_3, Произведение_4
            //останется в новом HashSet Произведение_1, Произведение_2, Произведение_3, Произведение_4
            //потом это сверится с новым у meloman_2 - "Произведение 2", "Произведение 3" и останется Произведение_2, Произведение_3
            //и с последним meloman_3 - "Произведение 1", "Произведение 3", "Произведение 4" и останется Произведение_3(которое нравится всем)

            all_music_liked.IntersectWith(meloman1);
            all_music_liked.IntersectWith(meloman2);
            all_music_liked.IntersectWith(meloman3);

            return all_music_liked;
        }

        public static HashSet<T> someone_likes<T>(HashSet<T> meloman1, HashSet<T> meloman2, HashSet<T> meloman3)
        {
            HashSet<T> someone_liked = new HashSet<T>();//пустое множество

            //объединение
            //например Произведение_1, Произведение_2, Произведение_3, Произведение_4 у meloman_1 и 0 у someone_liked
            //при объединении someone_liked получит в себя с 1-4 произведения, если будут новые, то он также их в себя добавит

            someone_liked.UnionWith(meloman1);
            someone_liked.UnionWith(meloman2);
            someone_liked.UnionWith(meloman3);

            return someone_liked;
        }

        public static HashSet<T> none_likes<T>(HashSet<T> musics, HashSet<T> someone_liked)
        {
            HashSet<T> none_liked = new HashSet<T>(musics); //множество со всеми типами произведений

            //грубо говоря - разность. Мы берем произведения, которые нравятся некоторым и вычитаем из всего списка эти произведения
            //разность - произведения, которые никому не нравятся

            none_liked.ExceptWith(someone_liked);

            return none_liked;
        }









        //задание_№4
        public static HashSet<char> unique_letters(string file_path)
        {
            HashSet<char> unique_letters = new HashSet<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };//гласные буквы

            HashSet<char> unique_letters_exist_1 = new HashSet<char>();//гласные, которые встречаются раз
            HashSet<char> letters_exist_1_more = new HashSet<char>(); //гласные, которые встречаются более чем в одном слове


            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(new[] { ' ', '\n', ',', '.', '!', '?', ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    //разбив строки на отдельные слова "Привет! Как дела?" -> "Привет", "Как", "дела"

                    foreach (var word in words)
                    {
                        HashSet<char> lower_word = new HashSet<char>();//будет содержать только уникальные символы из текущего слова

                        foreach (char ch in word.ToLower())
                        {
                            if (unique_letters.Contains(ch))//содержится ли текущий символ в наборе уникальных букв
                            {
                                lower_word.Add(ch); //символ найден в наборе, добавляем его в множество lower_word
                            }
                        }

                        //если найдены гласные, добавляем их в уникальные и повторяющиеся
                        if (lower_word.Count > 0)
                        {
                            //добавляем найденные гласные в уникальные
                            foreach (var letter in lower_word)
                            {
                                //если эта гласная уже встречалась в другом слове, помечаем её как повторяющуюся и записываем во множество
                                if (unique_letters_exist_1.Contains(letter))
                                {
                                    letters_exist_1_more.Add(letter);
                                }
                                else
                                {
                                    unique_letters_exist_1.Add(letter);
                                }
                            }
                        }
                    }

                    //удаляем гласные, которые встречаются более чем в одном слове из уникальных гласных
                    foreach (var letters in letters_exist_1_more)
                    {
                        unique_letters_exist_1.Remove(letters);
                    }
                }

            }


            return unique_letters_exist_1; //возвращаем множество гласных
        }














        //5 задание
    }

}
