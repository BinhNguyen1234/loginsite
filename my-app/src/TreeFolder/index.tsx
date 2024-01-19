'use client'
interface IData {
    folders : IFolder[]
}
export interface IFolder {
    name: string,
    id: string,
    folders: IFolder[] | never
}
export default function RepoTree({data, path, index}: {data: IFolder, path: string[], index: number}){
    const currentPath = path.length > index ? path[index] :path[path.length-1]
    console.log(currentPath)
    return (
        <ul>
            <span>{data.name}</span>
            <input type="radio" value={data.id} name="3213"></input>
            {RenderAllTreeItems({data: data.folders, path: path, index: index+1})}
        </ul>)
}
function RenderAllTreeItems({data, path, index}: {data: IFolder[], path: string[], index: number}){
    const currentPath = path.length > index ? path[index] : ""
    console.log(currentPath)
    return data.map((x,index) => <RepoTree index={index+1} path={path} key={x.id} data={x}></RepoTree>)
}

interface IWrapper {
    path: string[],
    folders: IFolder[]
}
export function Wrapper ({folders, path}: IWrapper){
    let index = 0;
    const currentPath = path[index]

    return RenderAllTreeItems({data: folders, path: path, index: index+1})
}