import { ReactNode } from "react";

export default function layouttype({children }: {children: ReactNode}){
    return <div>
            <div>Layout type</div>
            <div>{children}</div>
    </div>
}