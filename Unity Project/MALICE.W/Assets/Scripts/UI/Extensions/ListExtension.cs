using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MW.UI.Extensions {
    /// <summary>
    /// リスト操作を簡単に行うための<c>List</c>への拡張
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
        public static List<T> SpliceNd<T>(this List<T> self, int index, int count) {
            int length = self.Count;
            if((index + count) < length) return self.GetRange(index, count);
            else                         return self.GetRange(index, length - index);
        }
        
        /// <summary>
        /// IEnumerable<T>.Selectの結果をList<T>に変換する。Array.prototype.mapに相当
        /// </summary>
        /// <param name="f">適用する関数</param>
        public static List<U> Map<T, U>(this IEnumerable<T> self, Func<T, U> f) {
            return self.Select(f).ToList();
        }
        
        /// <summary>
        /// IEnumerable<T>.Whereの結果をList<T>に変換する。Array.prototype.filterに相当
        /// </summary>
        /// <param name="f">フィルターする関数</param>
        public static List<T> Filter<T>(this IEnumerable<T> self, Func<T, bool> f) {
            return self.Where(f).ToList();
        }
        
        /// <summary>
        /// リストを走査して、単一の値にする。
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="f">reduceに用いる関数</param>
        public static U Reduce<T, U>(this List<T> self, U firstValue, Func<T, U, U> f) {
            U outVal = firstValue;

            for(int i = 0;i < self.Count; i++)
                outVal = f(self[i], outVal);

            return outVal;
        }
        
        /// <summary>
        /// index番目の要素を取り出す。取り出された要素はリストから外される。
        /// </summary>
        /// <param name="index">インデックス</param>
        public static T TakeAt<T>(this List<T> self, int index) {
            var t = self[index];
            self.RemoveAt(index);
            return t;
        }
}}