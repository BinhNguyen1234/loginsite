'use client'
import Image from 'next/image'
import RepoTree, { Wrapper } from '../TreeFolder'
import json from "../TreeFolder/sample.json"
import { usePathname } from 'next/navigation'
import FormUpload from './FormUpload'
import Script from 'next/script'
import { useEffect, useMemo } from 'react'
export default function Home() {
  function onWorker (e: any){
    let worker = new Worker("/fff.js")
    worker.postMessage("fffff")
  }
  return (
    <main>
      {/* <div onChange={getChecked as any}>
        fff
      <Wrapper folders={json.folders} path={json.path} ></Wrapper>
      </div> */}
      <FormUpload></FormUpload>

      <Image src="/image-21.png" alt="me" width="64" height="64" ></Image>
      <Script strategy="worker" src="/fff.js"></Script>
    </main>
  )
}
