import { useMemo } from 'react';
import Frame from './Frames';

export default function Galaxy() {
    const Frames = useMemo(() => {
        const t = [];
        for (let i = 0; i < 4; i++) {
            t.push(<Frame key={i} index={i}></Frame>);
        }
        return t;
    },[]);
    return (
        <div
            style={{
                overflow: 'hidden',
                width: '100%',
                height: '100%',
                position: 'absolute'
            }}
        >
            {Frames}
        </div>
    );
}
