'use client'
import Image from 'next/image'
import RepoTree from '../TreeFolder'
import json from "../TreeFolder/sample.json"
import { usePathname } from 'next/navigation'
export default function Home() {
  let pathName = usePathname()
  console.log(123)
  function GetPathName(e:any){
    
    console.log(pathName)
  }
  return (
    <main>
      <div onClick={GetPathName}>Get Path Name</div>
      <RepoTree data={json}></RepoTree>
    </main>
  )
}
