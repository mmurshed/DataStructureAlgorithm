﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class BooleanParenthesization
    {
        /*
         * Source: http://qa.geeksforgeeks.org/4027/qa.geeksforgeeks.org/4027/many-ways-evaluate-expression-true-grouping-different-ways
         *
         * T|F
         * The operator here is 'or'. So, we need to find the number of 
         * ways sub-expression left of `|` operator, or the sub-expression 
         * to the right of the operator, evaluates to true. 
         * 
         * In other words,
         * ways = (ways_T_left * ways_T_right) + 
         *        (ways_F_left * ways_T_right) + 
         *        (ways_T_left * ways_F_right)
         * 
         * because T | T = T
         *         T | F = T
         *         F | T = T
         * 
         * We can extend the same analogy to other operators. 
         *  
         * 
         * Assume Tr(i, j) tell us the number of ways 
         * to get True from sub-expresion i to j
         * 
         * Fa(i, j) tell us the number of ways 
         * to get False from subexpresion i to j. 
         * 
         * 
         * The recurrence relation will look like the following : 
         * 
         * some rules => 
         * or operator:
         * T|F = T
         * T|T = T
         * F|T = T
         * F|F = F
         * 
         * and operator:
         * T&F = F
         * T&T = T
         * F&T = F
         * F&F = F
         * 
         * x-or operator
         * T^T = F
         * T^F = T
         * F^T = T
         * F^F = F
         * 
         * 
         * for Tr(i, j) :
         *     
         *     Loop from i to j - 1 into variable k
         *      
         *      IF(k == AND) :
         *     Tr(i, j) = Tr(i, j) + (Tr(i, k) * Tr(k + 1, j))
         * 
         *      IF(k == OR) :
         *     Tr(i, j) = Tr(i, j) + (Tr(i, k) * Tr(k + 1, j)) + 
         *                    (Tr(i, k) * Fa(k + 1, j)) + 
         *                    (Fa(i, k) * Tr(k + 1, j))
         * 
         *      If(k == XOR) :
         *     Tr(i, j) = Tr(i, j) + (Tr(i, k) * Fa(k + 1, j)) + 
         *                    (Fa(i, k) * Tr(k + 1, j))
         * 
         * for Fa(i, j) :
         *  
         *   Loop from i to j - 1 into variable k
         *    
         *    IF(k == AND) :
         *      Fa(i, j) = Fa(i, j) + (Fa(i, k) * Fa(k + 1, j)) + 
         *                 (Fa(i, k) * Tr(k + 1, j)) + 
         *                  (Tr(i, k) * Fa(k + 1, j))
         *                 
         *    IF(k == OR) :
         *     Fa(i, j) = Fa(i, j) + (Fa(i, k) * Fa(k + 1, j))
         *                 
         *    If(k == XOR) :
         *     Fa(i, j) = Fa(i, j) + (Tr(i, k) * Tr(k + 1, j)) + 
         *                    (Fa(i, k) * Fa(k + 1, j))
         * 
         * Source: https://www.geeksforgeeks.org/dynamic-programming-set-37-boolean-parenthesization-problem/
         * 
         * Given a boolean expression with following symbols.
         * 
         * Symbols
         * 'T' ---> true 
         * 'F' ---> false 
         * 
         * And following operators filled between symbols
         * 
         * Operators
         * &   ---> boolean AND
         * |   ---> boolean OR
         * ^   ---> boolean XOR 
         * 
         * Count the number of ways we can parenthesize the expression so that 
         * the value of expression evaluates to true.
         * 
         * Let the input be in form of two arrays one contains the symbols 
         * (T and F) in order and other contains operators (&, | and ^}
         * 
         * Examples:
         * Input: symbol[]    = {T, F, T}
         * operator[]  = {^, &}
         * 
         * Output: 2
         * The given expression is "T ^ F & T", it evaluates true
         * in two ways "((T ^ F) & T)" and "(T ^ (F & T))"
         * 
         * Input: symbol[]    = {T, F, F}
         * operator[]  = {^, |}
         * 
         * Output: 2
         * The given expression is "T ^ F | F", it evaluates true
         * in two ways "( (T ^ F) | F )" and "( T ^ (F | F) )".
         * 
         * Input: symbol[]    = {T, T, F, T}
         * operator[]  = {|, &, ^}
         * 
         * Output: 4
         * The given expression is "T | T & F ^ T", it evaluates true
         * in 4 ways ((T|T)&(F^T)), (T|(T&(F^T))), (((T|T)&F)^T) 
         * and (T|((T&F)^T)). 
         * 
         * 
         * Solution:
         * Let T(i, j) represents the number of ways to parenthesize the symbols
         * between i and j (both inclusive) such that the subexpression between 
         * i and j evaluates to true.
         * 
         * T(i, j)=
         *  for k=i to j-1
         *       T(i, k) * T(k + 1, j)                                 if operator[k] is &
         *       Total(i, k) * Total(k + 1, j) - F(i, k) * F(k + 1, j) if operator[k] is |
         *       T(i, k) * F(k + 1, j) + F(i, k) * T(k + 1)            if operator[k] is ^
         * 
         *       Total(i, j)= T(i, j) + F(i, j)
         * 
         * Let F(i, j) represents the number of ways to parenthesize the symbols
         * between i and j (both inclusive) such that the subexpression between
         * i and j evaluates to false.
         * 
         * F(i, j)=
         *   for k=i to j-1
         *       Total(i, k) * Total(k + 1, j) - T(i, k) * T(k + 1, j) if operator[k] is &
         *       F(i, k) * F(k + 1, j)                                 if operator[k] is |
         *       T(i, k) * T(k + 1, j) + F(i, k) * f(k + 1)            if operator[k] is ^
         * 
         *       Total(i, j) = T(i, j) + F(i, j)
         * 
         * Base Cases:
         * 
         * T(i, i) = 1 if symbol[i] = 'T' 
         * T(i, i) = 0 if symbol[i] = 'F' 
         * 
         * F(i, i) = 1 if symbol[i] = 'F' 
         * F(i, i) = 0 if symbol[i] = 'T'
         * 
         * If we draw recursion tree of above recursive solution, we can observe
         * that it many overlapping subproblems. Like other dynamic programming
         * problems, it can be solved by filling a table in bottom up manner. 
         * Following is C++ implementation of dynamic programming solution.
        */

        // Returns count of all possible parenthesizations that lead to
        // result true for a boolean expression with symbols like true
        // and false and operators like &, | and ^ filled between symbols
        // O(n^2)
        public static int CountParenthesis(string symb, string oper)
        {
            int n = symb.Length;
            var F = new int[n, n];
            var T = new int[n, n];

            // Fill diaginal entries first
            // All diagonal entries in T[i][i] are 1 if symbol[i]
            // is T (true).  Similarly, all F[i][i] entries are 1 if
            // symbol[i] is F (False)
            for (int i = 0; i < n; i++)
            {
                F[i, i] = (symb[i] == 'F') ? 1 : 0;
                T[i, i] = (symb[i] == 'T') ? 1 : 0;
            }

            // Now fill T[i, i+1], T[i, i+2], T[i, i+3]... in order
            // And F[i, i+1], F[i, i+2], F[i, i+3]... in order
            for (int gap = 1; gap < n; ++gap)
            {
                for (int i = 0, j = gap; j < n; ++i, ++j)
                {
                    T[i, j] = F[i, j] = 0;
                    // Find place of parenthesization using current value of gap
                    for (int k = i; k < j; k++)
                    {
                        // Store Total[i, k] and Total[k+1, j]
                        int tik = T[i, k] + F[i, k];
                        int tkj = T[k + 1, j] + F[k + 1, j];

                        // Follow the recursive formulas according to the current operator
                        if (oper[k] == '&')
                        {
                            T[i, j] += T[i, k] * T[k + 1, j];
                            F[i, j] += (tik * tkj - T[i, k] * T[k + 1, j]);
                        }
                        else if (oper[k] == '|')
                        {
                            F[i, j] += F[i, k] * F[k + 1, j];
                            T[i, j] += (tik * tkj - F[i, k] * F[k + 1, j]);
                        }
                        else if (oper[k] == '^')
                        {
                            T[i, j] += F[i, k] * T[k + 1, j] + T[i, k] * F[k + 1, j];
                            F[i, j] += T[i, k] * T[k + 1, j] + F[i, k] * F[k + 1, j];
                        }
                    }
                }
            }
            return T[0, n - 1];
        }

        // Driver program to test above function
        public static void Test()
        {
            string symbols = "TTFT";
            string operators = "|&^";

            // There are 4 ways
            // ((T|T)&(F^T)), (T|(T&(F^T))), (((T|T)&F)^T) and (T|((T&F)^T))
            Console.WriteLine(CountParenthesis(symbols, operators));
        }
    }
}
