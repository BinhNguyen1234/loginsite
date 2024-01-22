"use client";
import Image from "next/image";
import RepoTree, { Wrapper } from "../TreeFolder";
import json from "../TreeFolder/sample.json";
import { usePathname } from "next/navigation";
import FormUpload from "./FormUpload";
import Script from "next/script";
import { Suspense, useEffect, useMemo, useState } from "react";
import PostsComponent from "./TestSuspense/ffff";
export default function Home() {
  const data = new Promise((rs, rj) => {
    setTimeout(() => {
      rs("5");
    }, 10000);
  });
  const [abc, set] = useState({status: "peding",data: ""});
  useEffect(() => {
    const data = new Promise((rs, rj) => {
      setTimeout(() => {
        rs("5");
      }, 10000);
    });
    data.then((rs) => {
      return set({status: 'success', data: rs as any});
    });
  }, []);
  return (
    <main>
      {/* <div onChange={getChecked as any}>
        fff
      <Wrapper folders={json.folders} path={json.path} ></Wrapper>
      </div> */}
      <FormUpload></FormUpload>
      <Suspense fallback={<div>loaàasfasfasfasfding</div>}>
        <PostsComponent></PostsComponent>
      </Suspense>

      <Image src="/image-21.png" alt="me" width="64" height="64"></Image>
    </main>
  );
}

const a = new Promise((rs, rj) => {
  setTimeout(() => {
    rs("5");
  }, 3000);
});
