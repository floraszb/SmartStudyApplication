"use client";

import { useState } from "react";
import { generateAIResponse } from "@/lib/api";
import styles from "./dashboard.module.css";

export default function Dashboard() {
  const [prompt, setPrompt] = useState("");
  const [response, setResponse] = useState("");

  const handleSubmit = async () => {
    const aiResponse = await generateAIResponse(prompt);
    setResponse(aiResponse);
  };

  return (
    <div className={styles?.container}>
      <h1 className={styles?.title}>AI Dashboard</h1>

      <textarea
        className={styles?.textarea}
        value={prompt}
        onChange={(e) => setPrompt(e.target.value)}
        placeholder="Type your prompt here..."
      />

      <button className={styles?.button} onClick={handleSubmit}>
        Generate
      </button>

      <pre className={styles?.response}>{response}</pre>
    </div>
  );
}