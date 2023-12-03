namespace Extensions;

public static class EnumerableExtensions {

    public static IEnumerable<T> For<T>(this IEnumerable<T> enumerable, Action<T> action) {
        foreach (var element in enumerable) {
            action.Invoke(element);
            yield return element;
        }
    }

}