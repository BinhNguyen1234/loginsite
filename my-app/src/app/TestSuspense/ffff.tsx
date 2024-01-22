import React from "react";
import useGetData from "./index";

function PostsComponent() {
  const data = useGetData();

  return (
    <div>
      {data && data}
    </div>
  );
}

export default PostsComponent;