'use client'
import { useAppDispatch, useAppSelector } from "@/store/hook";
import {test} from '@/store/counter'
import { useEffect } from "react";
import { File } from "buffer";

export default function FormUpload() {
  return (
    <>
      <form onSubmit={submit}>
        <input type="file"></input>
        <button type="submit">submite</button>
      </form>
      {/* <button onClick={()=>alert(123123)}>123123</button> */}
    </>
  );
}
async function submit(e: any) {
  e.preventDefault();
  let file = e.target[0].files[0];
  // let a = new Worker("/worker/worker.js")
  // a.postMessage(file)
  const chunkSize = 1024 * 1024; // size of each chunk (1MB)
  let start = 0;
  await fetchByBatch(chunkSize, 3, 3000, file, 100)
}

async function fetchByBatch(chunkSize = 1024*1024, batch = 3, timeOut = 3000, file : any, retry = 1) {
  console.log(file)
  let start = 0;
  let part = 0;
  retry *= batch;
  let timeoutWhenFaild = timeOut * 10
  let timeOutWhenSuccess = timeOut
  while (start < file.size && retry > 0) {
    let request = [];
    for (let i = 0; i < batch; i++) {
      let c = new FormData()
      c.append("file",file.slice(start, start + chunkSize),`part-${part}.${file.name}`)
      part +=1
      request.push(
        fetch("http://localhost:5214/file/uploadfile", {
          method: 'post',
          body: c
        }).catch((e) => {
          alert(e)
          console.log(e)
          return e;
        })
      );
      start += chunkSize;
    }
    let FecthBacth = new Promise<void>((resolve, reject) => {
      setTimeout(() => {
        Promise.all(request).then((rs) => {
          rs.forEach((data) => {
            if (!data.ok) {
              start -= chunkSize;
              retry -=1;
              timeOut = timeoutWhenFaild
            } else {
              timeOut = timeOutWhenSuccess
            }
          });
          resolve();
        });
      }, timeOut);
    });
    await FecthBacth;
  }
}