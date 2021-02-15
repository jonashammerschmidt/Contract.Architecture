export function randomIndex(name: string, length: number): number {
    if (!name || name.length === 0) {
        return 0;
    }

    let index = 0;
    for (let i = 0; i < name.length; i++) {
        index += name.charCodeAt(i);
    }

    return index % length;
}
