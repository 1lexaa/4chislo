    using System;
        using System.Collections.Generic;

        namespace STL {
            partial class App 
            {
                public void Run() 
                {
                    DictionaryEx();
                }

                private void DictionaryEx() {
                    var dict = new Dictionary<String, String>();
                    dict.Add("dog", "собака");
                    dict.Add("house", "дом");
                    dict.Add("apple", "яблоко");
#region Menu
                    Console.WriteLine("Англо-русский словарь");
                    Console.WriteLine("1 - Найти перевод на Русский");
                    Console.WriteLine("2 - Найти перевод на Английский");
                    Console.WriteLine("3 - Добавить запись");
                    Console.WriteLine("0 - Выход");
#endregion
                    var keyPressed = Console.ReadKey(true);
                    while(keyPressed.KeyChar != '0') {
#region 1
                        if(keyPressed.KeyChar == '1') {
                            Console.WriteLine("Введите английское слово : ");
                            String enWord = Console.ReadLine();
                            String ruWord = null;
                            try {
                                ruWord = dict[enWord];
                            }
                            catch {
                                ruWord = "НЕ НАЙДЕНО";
                            }
                            finally {
                                Console.WriteLine($"Русское слово : {ruWord}");
                            }
                        }
                        #endregion

                        #region 2
                        else if(keyPressed.KeyChar == '2') {
                            Console.WriteLine("Введите русское слово : ");
                            String ruWord = Console.ReadLine();

                            foreach(var it in dict) 
                            {
                                if(it.Value == ruWord) {
                                    Console.WriteLine($"Перевод: {it.Key}");
                                    break;
                                }
                                else {
                                    Console.WriteLine("НЕ СУЩЕСТВУЕТ");
                                }
                            }
                        }
#endregion

#region Добавить запись
                else if (keyPressed.KeyChar == '3')
                {
                    Console.WriteLine("Добавление слова ");
                    Console.WriteLine("На англ : ");
                    String enWord = Console.ReadLine();
                    String ruWord = null;
                    try
                    {
                        dict.Add(enWord.ToLower(), ruWord.ToLower());
                        if (!Search(enWord))
                        {
                            Console.WriteLine("Успешно добавлено!");
                            Console.WriteLine("На русском : ");
                            ruWord = Console.ReadLine();
                            dict.Add(enWord.ToLower(), ruWord.ToLower());
                            Console.WriteLine($"{enWord} - {ruWord}");
                        }
                        else
                            dict.Remove(enWord.ToLower());
                    }
                    catch
                    {
                        if (Search(enWord))
                            Console.WriteLine("Такое слово уже есть!");
                        else
                            Console.WriteLine("Успешно добавлено!");
                        Console.WriteLine("На русском : ");
                        ruWord = Console.ReadLine();
                        dict.Add(enWord.ToLower(), ruWord.ToLower());
                        Console.WriteLine($"{enWord} - {ruWord}");
                    }
                    finally
                    {

                    }
                    
                }
                #endregion
        
                    
         bool Search(String arg)
        {
            List<String> list = new List<String>();
            foreach (var it in dict)
            {
                if (it.ToString().Contains(arg))
                {
                    list.Add(it.ToString());
                }
            }
            if (list.Count > 0)
            {
                return true;
            }
            else
                return false;

        }
                    }
                }
            }
        }
        
