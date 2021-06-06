export function distinctByField<T>(array: T[], fieldName: string): T[] {
    return [...new Map(array.map(item => [item[fieldName], item])).values()];
}
