using System.Collections;
using System.Collections.Generic;
public static class ListExtension {
    public static List<T> Splice<T>(this List<T> self, int index, int count) {
        int length = self.Count;
        if((index + count) < length) return self.GetRange(index, count);
        else                         return self.GetRange(index, length - index);
    }
}