'use client'
interface IData {
    repository : {
        name: string,
        folders: IFolder[]
    }
}
interface IFolder {
    name_folder: string,
    id: string,
    child_folder: IFolder[] | never
}
export default function RepoTree({data}: {data: IData}){

    return (
        <ul>
            <span>{data.repository.name}</span>
            {RenderAllTreeItems({data: data.repository.folders})}
        </ul>)
}
function RenderAllTreeItems({data}: {data: IFolder[]}){
    return data.map((x,index) => TreeItem({data:x}))
}
function TreeItem({data, className}: {data: IFolder, className?: string}){
    function onCl(e: any) {
        e.stopPropagation();
        e.target.classList.toggle("activee")
    }
    function onCl2(e: any) {
        console.log(e)
    }
    return (
    <>
        <li  onClick={onCl} className="pl-1.5 nested" id={data.id}>
            <span onClick={onCl2}>{data.name_folder}</span>
            {data.child_folder.length > 0 ? TreeItems(data.child_folder) : null}
        </li>
    </>)
}
function TreeItems(data : IFolder[]){
    return data.map((data,index) => <TreeItem key={data.id} data={data}></TreeItem>)
}