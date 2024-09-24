// get day different
export function getDayDifferent( dueTo: Date) {
    const timeDiff = dueTo.getTime() - new Date().getTime();
    return timeDiff / (1000 * 3600 * 24);
}