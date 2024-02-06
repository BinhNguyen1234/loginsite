'use client'
import { useAppDispatch, useAppSelector } from "@/store/hook";
import {test} from '@/store/counter'
import { useEffect } from "react";
import a from "./wok"
export default function FormUpload() {
  const disPatch = useAppDispatch();
  useEffect(()=>{disPatch({type:"token/fff", payload: "765756767567"})},[])
  return (
    <>
      <form onSubmit={submit}>
        <input type="file"></input>
        <button type="submit">submite</button>
      </form>
      <button onClick={()=>alert(123123)}>123123</button>
    </>
  );
}
async function submit(e: any) {
  e.preventDefault();
  console.log(e);
  let file = e.target[0].files[0];

  a.postMessage(file)
}

