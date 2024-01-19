'use client'
import Image from 'next/image'
import RepoTree, { Wrapper } from '../TreeFolder'
import json from "../TreeFolder/sample.json"
import { usePathname } from 'next/navigation'
export default function Home() {
  function getChecked(e: any){
    console.log(e.target)
  }
  return (
    <main>
      <div onChange={getChecked as any}>
        fff
      <Wrapper folders={json.folders} path={json.path} ></Wrapper>
      </div>
      
    </main>
  )
}
