async function FetchComponent(reqParams) {
  const headers = {
    method: "GET",
    accept: "application/json",
    "Access-Control-Allow-Origin":"*",
    "Access-Control-Allow-Credentials":"true",
    "content-type": "application/json"     
  };
  return await fetch(reqParams, { headers });
}

export default FetchComponent;
