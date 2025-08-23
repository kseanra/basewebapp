import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

export default function SignOut() {
    const navigate = useNavigate();

    useEffect(() => {
        localStorage.removeItem("auth");
        navigate("/")
    }, []);
}