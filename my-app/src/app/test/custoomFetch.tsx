import { a } from "@/store/counter";

export default async function customFetch(
  url: string,
  { ...config }: RequestInit,
  retry: number = 1
) {
  const retryI = retry - 1;
  if (retry < 0) throw new Error();
  let data = await fetch(url, config);

  let token:any = "";
  if (!data.ok) {
    if (data.status == 401) {
      token = await customFetch(
        "http://localhost:5252/api/user/authenticate",
        {
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          method: "Post",
          body: JSON.stringify({ Email: "binh123", Password: " binh123" }),
        },
        0
      );
      data = await customFetch(url, {headers:{Authorization: `Bearer  ${token.token}`}}, retryI);
      console.log(data)
    }
    throw new Error();
  }
  return data.json();
}
