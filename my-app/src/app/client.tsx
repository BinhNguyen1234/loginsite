'use client'

import { useRouter } from "next/navigation"
import { useEffect, useState } from "react"

export default function CLientSide({Data}: {Data : {num: number}}){
    const router = useRouter()
    useEffect(()=>{
        console.log(123123)
    },[Data])
    useEffect(()=>{
        console.log("MOunted")
    },[])
    const [state, setState] = useState(1)
    return <>
    <div>{Data.num}</div>
    <button onClick={()=>{
        console.log("click")
        router.refresh()
    }}>Refesh</button>
        <button onClick={()=>{
        console.log("click")
        setState( state => state + 1);
    }}>+</button>
    <div>{state}</div>
    </>
}