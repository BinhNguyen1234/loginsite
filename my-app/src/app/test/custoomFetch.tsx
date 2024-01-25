import { a } from "@/store/counter";


async function customFetch(url: string, {...config}: any, retry: number = 1){
    const retryI = retry - 1
    if(retry < 0) throw new Error()
    let data = await fetch(url, config)
    let token = ""
    if(!data.ok){
        if(data.status == 401){
            token = await customFetch("auth", {}, 0)
            data = await customFetch(url,{},retryI)
        }
        throw new Error()
    }
    return data.json()
}