'use client'
import { Suspense } from "react"
import { prms } from "./promise"
export default function Test() {
    let data = prms
return <Suspense fallback={<div>loading</div>}>
    <Item data={data}></Item>
</Suspense>
}
function Item({data}:{data:any}){
    return <div>{data}</div>
}