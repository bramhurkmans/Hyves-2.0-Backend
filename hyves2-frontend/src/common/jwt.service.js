const AUTH_TOKEN = "auth_token";

export const getToken = () => {
  return getCookie('bearer_token')
};

export const saveToken = token => {
  window.localStorage.setItem(AUTH_TOKEN, token);
};

export const destroyToken = () => {
  window.localStorage.removeItem(AUTH_TOKEN);
};

function getCookie(cname) {
  let name = cname + "=";
  let decodedCookie = decodeURIComponent(document.cookie);
  let ca = decodedCookie.split(';');
  for(let i = 0; i <ca.length; i++) {
    let c = ca[i];
    while (c.charAt(0) == ' ') {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

export default { getToken, saveToken, destroyToken };
