import { NextResponse } from "next/server";
import { NextRequest } from "next/server";

// This function can be marked `async` if using `await` inside
export function middleware(request: NextRequest) {
  let cookie = request.cookies.get("vercel");
  const header = new Headers(request.headers);
  header.set("Authorization", "Bearer asfasfasfasfasf");
  header.set("FFFFF", "Bearer asfasfasfasfasf");
  // console.log(request.headers.forEach(x => console.log(x, "middleware")))
    const response = NextResponse.next({ request: { headers: header } });
    console.log(response.status)
    response.cookies.set({
        name: 'vercel',
        value: 'fast',
        path: '/',
        httpOnly: true,
        
      })
      console.log(response)
  return response
}
