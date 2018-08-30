using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MW.UI.ListExtension {
    /// <summary>
    /// リスト操作を簡単に（そしてJavaScript風に）行うための<c>List</c>への拡張
    /// </summary>
    public static class ListExtension {
        /// <summary>
        /// JavaScriptのArray.prototype.spliceに準ずる。リストの<c>index</c>番目から<c>count</c>までを取り出す。
        /// </summary>
        /// <param name="index">操作の開始位置</param>
        /// <param name="count">取り出す個数</param>
        public static List<T> Splice<T>(this List<T> self, int index, int count) {
            int length = self.Count;
            List<T> res;
            if((index + count) < length) res = self.GetRange(index, count);
            else {
                count = length - index;
                res   = self.GetRange(index, count);
            }
            self.RemoveRange(index, count);
            return res;
        }
        /// <summary>
        /// JavaScriptのArray.prototype.spliceの非破壊版。
        /// リストの<c>index</c>番目から<c>count</c>までを非破壊的に取り出す。
        /// </summary>
        /// <param name="index">操作の開始位置</param>
        /// <param name="count">取り出す個数</param>
        public static List<T> SpliceND<T>(this List<T> self, int index, int count) {
            int length = self.Count;
            if((index + count) < length) return self.GetRange(index, count);
            else                         return self.GetRange(index, length - index);
        }

        public static List<U> Map<T, U>(this List<T> self, Func<T, U> f) {
            return self.Select(f).ToList();
        }

        public static List<T> Filter<T>(this List<T> self, Func<T, bool> f) {
            return self.Where(f).ToList();
        }

        public static T Reduce<T>(this List<T> self, Func<T, T, T> f) {
            return self.Aggregate(f);
        }

        public static U Reduce<T, U>(this List<T> self, U firstValue, Func<T, U, U> f) {
            U _val = firstValue;

            for(int i = 0;i < self.Count; i++)
                _val = f(self[i], _val);

            return _val;
        }
}}