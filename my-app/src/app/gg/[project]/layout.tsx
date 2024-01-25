import { ReactNode } from "react";

export default function layoutFF ({children }: {children: ReactNode}){
    return <div>
            <div>Layout project</div>
            <div>{children}</div>
    </div>
}