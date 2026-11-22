import {Button} from "@/components/ui/button";
export default function Home(){
  return (
    <main className="flex min-h-screen flex-col items-center justify-center gap-6 p-8">
      <h1 className="text-4xl font-bold">SlotEngine</h1>
      <p className="text-muted-foreground text-center">
        La plataforma para gestionar tu negocio de servicios.
      </p>
      <Button>Comenzar</Button>
    </main>
  );
}
