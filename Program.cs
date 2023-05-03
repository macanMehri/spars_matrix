using System;


namespace SparsProject
{
    class Matrix
    {
        private int rows;
        private int columns;
        public int[,] values;
        //property for row
        public int Rows
        {
            get { return rows; }
            set 
            { 
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("row", value, "Number of rows must be greater than 0!");
                rows = value;
            }
        }
        //property for column
        public int Columns
        {
            get { return columns; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("column", value, "Number of columns must be greater than 0!");
                columns = value;
            }
        }
        //تابع سازنده
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            values = new int[rows, columns];
        }
        //display matrix
        public void show_matrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    Console.Write(string.Format("{0,-5}", values[i, j]));
                Console.WriteLine();
            }
        }
        //adding values in 2D array for matrix
        public void add_values()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write("Please enter value of row number {0} and column number {1}: ", i + 1, j + 1);
                    values[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        //a function for counting datas that are not zero in the matrix
        public int data_number()
        {
            int data_count = 0;
            foreach (var item in values)
            {
                if (item != 0)
                    data_count++;
            }
            return data_count;
        }
        //taranahad
        public void transposition()
        {
            int [,] trn = new int[Columns, Rows];
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                    trn[j, i] = values[i, j];
            }

            int temp = Rows;  
            Rows = Columns;
            Columns = temp;

            values = trn;
        }
        //tis function checks if your matrix is spars or not      true for spars     false for not spars
        public bool is_spars()
        {
            if (data_number() <= (Columns * Rows)/3)
                return true;
            return false;
        }
        //ماتریسی میسازد که مقادیر غیر صفر را با شماره سطر و ستون ذخیره می کند
        public Matrix values_matrix()
        {
            Matrix values_matrix = new Matrix(data_number(), 3);
            int k = 0;
            for (int i = 0; i < Rows; i++)    
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (values[i, j] != 0)
                    {
                        values_matrix.values[k, 0] = i + 1;
                        values_matrix.values[k, 1] = j + 1;
                        values_matrix.values[k, 2] = values[i, j];
                        k++;
                    }
                }
            }
            return values_matrix;
        }
        //ضرب دو ماتریس 
        public Matrix multiplication_matrices(Matrix m)
        {
            if(Columns != m.Rows)
            {
                Console.WriteLine("You cannot multiplication this two matrices!");
                return null;
            }    
            int sum;
            Matrix answer = new Matrix(Rows, m.Columns);
            for (int i = 0; i < Rows; i++)                       // شمارنده سطرهای متریس اول
            {
                
                for (int k = 0; k < m.Columns; k++)              // شمارنده ستون های ماتریس نهایی
                {
                    sum = 0;
                    for (int j = 0; j < Columns; j++)            // شمارنده ستون های ماتریس اولی
                    {
                        sum += values[i, j] * m.values[j, k];
                    }
                    answer.values[i, k] = sum;
                }
                
            }
            return answer;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Check a matrix for being spars \n2. Transposition a matrix \n3. If matrix is spars creat new matrix of datas \n4. Multiplication of two matrices \n5. Multiplication of two data matrices \n6. Project final result! \n0. Quit");
                    Console.Write("\nPlease enter your choice: ");
                    int order = Convert.ToInt32(Console.ReadLine());
                    switch (order)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.Clear();
                            Matrix x0 = creat_matrix();
                            x0.show_matrix();
                            Console.WriteLine("------------------");
                            if (x0.is_spars())
                                Console.WriteLine("Your matrix is spars!");
                            else
                                Console.WriteLine("Your matrix is not spars!");
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Matrix x = creat_matrix();
                            Console.WriteLine("---------first matrix--------");
                            x.show_matrix();
                            x.transposition();
                            Console.WriteLine("---------transpositioned matrix--------");
                            x.show_matrix();
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Matrix x2 = creat_matrix();
                            Console.WriteLine("---------first matrix--------");
                            x2.show_matrix();
                            if (x2.is_spars())
                            {
                                Console.WriteLine("---------matrix of datas--------");
                                x2.values_matrix().show_matrix();
                            }
                            else
                                Console.WriteLine("Your matrix is not spars!");
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Matrix x3 = creat_matrix();
                            Matrix x4 = creat_matrix();
                            Console.WriteLine("---------first matrix--------");
                            x3.show_matrix();
                            Console.WriteLine("---------second matrix--------");
                            x4.show_matrix();
                            Console.WriteLine("---------multiplication matrices--------");
                            if (x3.multiplication_matrices(x4) != null)
                                x3.multiplication_matrices(x4).show_matrix();
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            Matrix x5 = creat_matrix();
                            Matrix x6 = creat_matrix();
                            Console.WriteLine("---------first matrix--------");
                            x5.show_matrix();
                            Console.WriteLine("---------second matrix--------");
                            x6.show_matrix();
                            if (x5.is_spars() && x6.is_spars())
                            {
                                Matrix x5_value = x5.values_matrix();
                                Console.WriteLine("---------first matrix of datas--------");
                                x5_value.show_matrix();
                                Matrix x6_value = x6.values_matrix();
                                Console.WriteLine("---------second matrix of datas--------");
                                x6_value.show_matrix();
                                Console.WriteLine("---------multiplication of data matrices--------");
                                if (x5_value.multiplication_matrices(x6_value) != null)
                                    x5_value.multiplication_matrices(x6_value).show_matrix();
                            }
                            else
                                Console.WriteLine("One or more of your matrices are not spars!");
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            Matrix x7 = creat_matrix();
                            Matrix x8 = creat_matrix();
                            Console.WriteLine("---------first matrix--------");
                            x7.show_matrix();
                            Console.WriteLine("---------second matrix--------");
                            x8.show_matrix();
                            if (x7.is_spars() && x8.is_spars())
                            {
                                Matrix x7_value = x7.values_matrix();
                                Console.WriteLine("---------first matrix of datas--------");
                                x7_value.show_matrix();
                                Matrix x8_value = x8.values_matrix();
                                Console.WriteLine("---------second matrix of datas--------");
                                x8_value.show_matrix();
                                x7_value.transposition();
                                x8_value.transposition();
                                Console.WriteLine("---------transpositioned first matrix of datas--------");
                                x7_value.show_matrix();
                                Console.WriteLine("---------transpositioned second matrix of datas--------");
                                x8_value.show_matrix();
                                Console.WriteLine("---------multiplication of transpositioned data matrices--------");
                                if (x7_value.multiplication_matrices(x8_value) != null)
                                    x7_value.multiplication_matrices(x8_value).show_matrix();
                            }
                            else
                                Console.WriteLine("One or more of your matrices are not spars!");
                            Console.WriteLine("\nPress any key to return to menu!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //a function for creating a matrix
            Matrix creat_matrix()
            {
                Console.Clear();
                Console.Write("Please enter number of rows your matrix have: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter number of columns your matrix have: ");
                int column = Convert.ToInt32(Console.ReadLine());
                Matrix x = new Matrix(row, column);
                x.add_values();
                Console.Clear();
                return x;
            }
            Console.ReadKey();
        }
    }
}
