export default function FormUpload() {
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
  let a = new Worker("/fff.js")
  a.postMessage(file)
}
