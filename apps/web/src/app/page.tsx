import { Button } from "@/components/ui/button";
import { Suspense } from "react";

async function getApiHealth(): Promise<boolean> {
  const apiUrl = process.env.SLOTENGINE_API_URL;

  if (!apiUrl) {
    return false;
  }

  try {
    const response = await fetch(`${apiUrl}/health`, {
      cache: "no-store",
      signal: AbortSignal.timeout(3000),
    });

    return response.ok;
  } catch {
    return false;
  }
}

async function ApiHealthStatus() {
  const apiHealthy = await getApiHealth();
  return (
    <p role="status" className="text-sm">
      Estado de la API:{" "}
      <span className={apiHealthy ? "text-green-600" : "text-red-600"}>
        {apiHealthy ? "Disponible" : "No Disponible"}
      </span>
    </p>
  );
}

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-center gap-6 p-8">
      <h1 className="text-4xl font-bold">SlotEngine</h1>
      <p className="text-muted-foreground text-center">
        La plataforma para gestionar tu negocio de servicios.
      </p>

      <Button>Comenzar</Button>

      <Suspense fallback={
        <p role="status" className="text-sm">
          Estado de la API: Comprobando...
        </p>
      }>
        <ApiHealthStatus />
      </Suspense>
    </main>
  );
}
