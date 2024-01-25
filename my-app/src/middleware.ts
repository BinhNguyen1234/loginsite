import { NextResponse } from "next/server";
import { NextRequest } from "next/server";

// This function can be marked `async` if using `await` inside
export function middleware(request: NextRequest) {
  console.log("first");
  let cookie = request.cookies.get("acc_tok");
  NextResponse.error()
  const header = new Headers(request.headers);
  header.set("Authorization", "Bearer Token");
  // console.log(request.headers.forEach(x => console.log(x, "middleware")))
    const response = NextResponse.next({ request: { headers: header } });
    response.cookies.set({
        name: 'vercel',
        value: 'fast',
        path: '/',
        httpOnly: true,
        
      })
    console.log(response.status)
  return response
}
