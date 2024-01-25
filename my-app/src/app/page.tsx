
import Image from "next/image";
import RepoTree, { Wrapper } from "../TreeFolder";
import json from "../TreeFolder/sample.json";
import { usePathname } from "next/navigation";
import FormUpload from "./FormUpload";
import Script from "next/script";
import { Suspense, useEffect, useMemo, useState } from "react";
import Test from "./TestSuspense/test2/component";
import { headers } from 'next/headers'
export default async function Home() {
  console.log("second")

  await fetch("http://localhost:5252/api/user/authozire",{headers: headers()})
  const data = new Promise((rs, rj) => {
    setTimeout(() => {
      rs("5");
    }, 10000);
  });
  throw new Error()
  
  // const [abc, set] = useState({status: "peding",data: ""});
  // useEffect(() => {
  //   const data = new Promise((rs, rj) => {
  //     setTimeout(() => {
  //       rs("5");
  //     }, 10000);
  //   });
  //   data.then((rs) => {
  //     return set({status: 'success', data: rs as any});
  //   });
  // }, []);
  return (
    <main>
      {/* <div onChange={getChecked as any}>
        fff
      <Wrapper folders={json.folders} path={json.path} ></Wrapper>
      </div> */}
      {/* <<FormUpload></FormUpload>
      <Test></Test>> */}
      <div>12312</div>
    </main>
  );
}

// const a = new Promise((rs, rj) => {
//   setTimeout(() => {
//     rs("5");
//   }, 3000);
// });
