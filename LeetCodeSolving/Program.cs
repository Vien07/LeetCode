
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

    public bool IsAnagramBest(string s, string t)
    {
        var dictS = new Dictionary<char, int>();
        var dictT = new Dictionary<char, int>();

        if (s.Length != t.Length) return false;
        for (int i = 0; i < s.Length; i++)
        {
            if (dictS.ContainsKey(s[i]))
            {
                dictS[s[i]]++;
            }
            else
            {
                dictS.Add(s[i], 1);
            }
            if (dictT.ContainsKey(t[i]))
            {
                dictT[t[i]]++;
            }
            else
            {
                dictT.Add(t[i], 1);

            }
        }
        foreach (var d in dictS)
        {
            if (!(dictT.ContainsKey(d.Key) && dictT[d.Key] == d.Value)) return false;
        }
        return true;

    }
    // 3. Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

    //You may assume that each input would have exactly one solution, and you may not use the same element twice.

    //You can return the answer in any order.
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexNum = new();
        for (int i = 0; i < nums.Length; i++)
        {
            var compliment = target - nums[i];
            if (indexNum.ContainsKey(compliment))
            {
                return new int[] { i, indexNum[compliment] };
            }
            indexNum[nums[i]] = i;
        }
        return null;
    }
    // 4. Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groupedAnagrams = new Dictionary<string, IList<string>>();

        foreach (string str in strs)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new string(charArray);

            if (!groupedAnagrams.ContainsKey(sortedStr))
            {
                groupedAnagrams[sortedStr] = new List<string>();
            }

            groupedAnagrams[sortedStr].Add(str);
        }

        return groupedAnagrams.Values.ToList();
    }
    // 5. Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
    public int[] TopKFrequent(int[] nums, int k)
    {

        return null;
    }
}