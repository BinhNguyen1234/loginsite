
import { cookies, headers } from 'next/headers'
import FormUpload from "./FormUpload";
import CLientSide from "./client";
export default async function Home() {
  console.log(headers().get('FFFFF'))
  const data = {num: 6}
  const a = await fetch('http://localhost:5214/file/runserviffce').then( x => {
    if(!x.ok){
      throw new Error()
    }
  })

  // customFetch("http://localhost:5252/api/user/authozire",{method: "get"}).then(rs => {
  //   setState(rs)
  // })

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
    <>
    <main>
      {/* <div onChange={getChecked as any}>
        fff
      <Wrapper folders={json.folders} path={json.path} ></Wrapper>
      </div> */}
       <FormUpload></FormUpload>
       <CLientSide Data={data}></CLientSide>
      {/* <Test></Test>  */}
      {/* <div>12312</div> */}
    </main></>

  );
}
export const dynamic = 'force-dynamic' 



// const a = new Promise((rs, rj) => {
//   setTimeout(() => {
//     rs("5");
//   }, 3000);
// });
