import { useMemo } from 'react';

export default function Star() {
    const getWidth = useMemo(() => {
        return Math.random() * 4 + 'px';
    }, []);
    const getPosition = useMemo(() => {
        return Math.random() * 100 + '%';
    }, []);
    const getTop = useMemo(() => {
        return Math.random() * 100 + '%';
    }, []);
    return (
        <div
            className='star'
            style={{ width: getWidth, left: getTop, top: getPosition }}
        ></div>
    );
}
