export function getToken(){
    return localStorage.getItem("token");
}

export function isLoggedIn(){
    return !!getToken();
}

export function logout(){
    return localStorage.removeItem("token");
}