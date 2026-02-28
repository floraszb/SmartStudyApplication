// frontend/src/lib/api.ts

const API_URL = process.env.NEXT_PUBLIC_API_URL;

// Generic API fetch helper
export async function apiFetch(endpoint: string, options?: RequestInit) {
  // Only access localStorage on the client
  const token =
    typeof window !== "undefined" ? localStorage.getItem("token") : null;

  return fetch(`${API_URL}${endpoint}`, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      Authorization: token ? `Bearer ${token}` : "",
      ...options?.headers,
    },
  });
}

// AI-specific API call
export async function generateAIResponse(prompt: string): Promise<string> {
  try {
    const res = await apiFetch("/api/ai/generate", {
      method: "POST",
      body: JSON.stringify({ prompt }),
    });

    if (!res.ok) {
      const errorText = await res.text();
      throw new Error(`AI request failed: ${errorText}`);
    }

    const data = await res.json();
    return data.response || "No AI response received";
  } catch (err: any) {
    console.error("Error calling AI:", err);
    return `Error: ${err.message}`;
  }
}