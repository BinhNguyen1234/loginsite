'use client'
import { useState } from "react";
import { createPortal } from "react-dom";

export default function Mod (){
    console.log(document, "FF")
    const [state, setState] = useState(false)
    function T () {
        return state && <div><TTTT></TTTT></div>
    }
    return [T as any ,setState] 
}
function TTTT () {
    console.log(document, "FF")
    return createPortal(<div>Proádasdasdasdasdasdtal</div>, document.getElementById("test-portal") as HTMLElement)
}