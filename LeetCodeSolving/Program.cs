
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

public class LeetCode
{
    // 1. Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return true;
            }
            else
            {
                set.Add(num);
            }
        }

        return false;
    }
    // 2. Given two strings s and t, return true if t is an anagram of s, and false otherwise.
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> sCounts = new Dictionary<char, int>();
        Dictionary<char, int> tCounts = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!sCounts.ContainsKey(c))
            {
                sCounts[c] = 1;
            }
            else
            {
                sCounts[c]++;
            }
        }

        foreach (char c in t)
        {
            if (!tCounts.ContainsKey(c))
            {
                tCounts[c] = 1;
            }
            else
            {
                tCounts[c]++;
            }
        }

        foreach (var kvp in sCounts)
        {
            if (!tCounts.ContainsKey(kvp.Key) || tCounts[kvp.Key] != kvp.Value)
            {
                return false;
            }
        }

        return true;
    }
    // 3.Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

    //You may assume that each input would have exactly one solution, and you may not use the same element twice.

    //You can return the answer in any order.

}