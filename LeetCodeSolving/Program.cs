
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
        List<int> result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    result.Add(i);
                    result.Add(j);
                    return result.ToArray();
                }
            }
        }
        return result.ToArray();
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
        var listNumsWithCount = new Dictionary<int, int>();
        foreach (int i in nums)
        {
            if (!listNumsWithCount.ContainsKey(i))
            {
                listNumsWithCount[i] = 0;
            }
            listNumsWithCount[i]++;
        }
        var sortedKeys = listNumsWithCount.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();
        var result = new List<int>();
        for (int j = 0; j < k; j++)
        {
            result.Add(sortedKeys[j]);
        }

        return result.ToArray();
    }
    // 6. Design an algorithm to encode a list of strings to a single string. The encoded string is then decoded back to the original list of strings.
    public string Encode(IList<string> strs)
    {
        string encodeString = "";
        foreach (string str in strs)
        {
            encodeString += str.Length.ToString() + "#" + str;
        }
        return encodeString;
    }

    public List<string> Decode(string s)
    {
        var decodedList = new List<string>();
        int i = 0;

        while (i < s.Length)
        {
            int j = i;
            while (s[j] != '#')
            {
                j++;
            }

            int length = int.Parse(s.Substring(i, j - i));
            i = j + 1; 
            string str = s.Substring(i, length);
            decodedList.Add(str);
            i += length; 
        }

        return decodedList;
    }
    // 7. Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
    // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
    // You must write an algorithm that runs in O(n) time and without using the division operation.

    // ** Work but slow **
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new List<int>();
        var i = 0;

        while (i < nums.Length)
        {

            int t = 1;
            for(var j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    t = t * nums[j];
                }
            }

            result.Add(t);
            i++;
        }

        return result.ToArray();
    }

    public int[] ProductExceptSelfFast(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        int leftProduct = 1;
        for (int i = 0; i < n; i++)
        {
            result[i] = leftProduct;
            leftProduct *= nums[i];
        }

        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return result;
    }
}