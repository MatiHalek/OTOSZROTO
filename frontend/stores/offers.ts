interface Offer {
    advertisementID: number;
    advertismentImages: any[];
    bodyType: string | null;
    category: string | null;
    color: string | null;
    condition: string | null;
    description: string | null;
    displacement: number;
    email: string | null;
    fuelType: string | null;
    gearbox: string | null;
    isPriceNegotiable: boolean;
    mileage: number;
    model: string | null;
    numberOfDoors: number;
    numberOfPlaces: number;
    phoneNumber: string | null;
    power: number;
    price: number;
    title: string;
    vin: string | null;
    yearOfProduction: number;
}

export const useOffersStore = defineStore('offersStore', {
    state: () => ({
        offers: [] as Offer[]
    }),
    actions: {
        async getOffers() {
            const { data } = await useFetch<Offer[]>('http://localhost:5271/api/advertisment', {
                method: 'get',
                responseType: 'json',
            });

            this.offers = data.value || [];
        }
    }
  })