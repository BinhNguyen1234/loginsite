'use client'
import { useAppSelector } from "@/store/hook";

export default function FormUpload() {
  const accessToken = useAppSelector(state => state)
  console.log(accessToken)
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
  let a = new Worker("/worker/worker.js")
  a.postMessage(file)
}
