import React from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useAppContext } from "../AppContext";

function GoogleRedirected() {
    const navigate = useNavigate();
    const { login } = useAppContext();

    const code = new URLSearchParams(window.location.search).get("code");

    useEffect(() => {
        if (code) {
            fetch(`${import.meta.env.VITE_API_URL}/api/oauth2/google?code=${code}&redirect_uri=${import.meta.env.VITE_GOOGLE_REDIRECT_URI}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                }
            })
                .then((response) => response.json())
                .then((data) => {
                    console.log(data);
                    login(data.accessToken, data.refreshToken);
                    navigate("/");
                })
                .catch((err) => {
                    navigate(`/unauthorize`);
                });
        }
    }, [code, login, navigate]);
    

    //get code from params
    

    return (
        <div> Loading </div>
    );
}

export default GoogleRedirected;