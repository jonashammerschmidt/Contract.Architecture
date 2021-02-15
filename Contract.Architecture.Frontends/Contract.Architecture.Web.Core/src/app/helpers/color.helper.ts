import { randomIndex } from './random.helper';

const colors = [
    '#e51c23',
    '#673ab7',
    '#ff5722',
    '#259b24',
    '#03a9f4',
    '#795548',
    '#afb42b',
    '#607d8b',
    '#009688',
    '#8bc34a',
    '#9c27b0',
    '#5677fc',
    '#e91e63',
    '#3f51b5',
    '#ff9800',
    '#00bcd4',
];

export function toRGB(str: string): string {
    return colors[randomIndex(str, colors.length)];
}
