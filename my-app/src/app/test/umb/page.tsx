import Link from "next/link"

export default function PageTest({children}: any){
    console.log("pageTest")
    return <div>
        <Link href="/test/photo">Pho</Link>
        <div>Page umb</div>
    </div>
}