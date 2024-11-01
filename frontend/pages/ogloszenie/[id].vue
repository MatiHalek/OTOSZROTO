<template>
    <main>
	    <iframe class="w-100" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2580.6341520898554!2d20.41741487692789!3d49.69886194119375!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47161cd0d7dfe0e5%3A0x8b8e90f28d06c112!2zWmVzcMOzxYIgU3prw7PFgiBUZWNobmljem55Y2ggaSBPZ8OzbG5va3N6dGHFgmNhY3ljaCBpbS4gSmFuYSBQYXfFgmEgSUk!5e0!3m2!1spl!2spl!4v1704599107714!5m2!1spl!2spl" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        <article class="container-lg" id="advertisementInfo">
            <section class="d-grid">
                <section class="align-items-center justify-content-center d-flex flex-column" id="saveApplySection">
                    <button id="saveButton" class="w-75 dangerButton border-0" type="button"><i class="bi bi-star me-2"></i>email</button>
                    <button id="applyButton" class="w-75 successButton border-0" type="button"><i class="bi bi-check-circle me-2"></i>phoneNumber</button>
                </section>
                <section>
                    <h1 class="fs-2">Tytuł
                        <span class="fs-6">#000001</span>
                    </h1>
                    <h2 class="fs-5 text-secondary fw-bold">Kategoria</h2>
                    <div class="d-flex justify-content-between flex-wrap">
                        <p class="me-3"><i class="bi bi-calendar-plus-fill me-2"></i>Stan: condition</p>
                        <p><i class="bi bi-calendar-check-fill me-2"></i>Rok produkcji: yearOfProduction</p>
                    </div>
                    <div class="mx-auto bg-success-subtle p-4 p-sm-2 rounded-pill">
                        <h3 class="text-center text-success fw-bold mb-0"><i class="bi bi-cash-coin me-2"></i>Cena</h3>
                        <p>Do negocjacji</p>
                    </div>
                </section>
                <section>
                    <div class="row">
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-pencil-square"></i>
                            </div>
                            <div>
                                <strong class="text-secondary">Przebieg</strong>
                                <p>mileage</p>
                            </div>
                        </div>
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-person-vcard-fill"></i>
                            </div>
                            <div>
                                <strong class="text-secondary">Rodzaj paliwa</strong>
                                <p>fuelType</p>
                            </div>
                        </div>
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-person-standing"></i>
                            </div>
                            <div>
                                <strong class="text-secondary">Skrzynia biegów</strong>
                                <p>gearBox</p>
                            </div>
                        </div>
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-clock-fill"></i>
                            </div>
                            <div>
                                <strong class="text-secondary">Typ nadwozia</strong>
                                <p>bodyType</p>
                            </div>
                        </div>
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-person-workspace"></i>
                            </div>
                            <div>
                                <strong class="text-secondary">Pojemność skokowa</strong>
                                <p>displacement</p>
                            </div>
                        </div>
                        <div class="d-flex col-md-6 jobInfo">
                            <div class="bg-secondary mt-2 rounded d-flex align-items-center justify-content-center jobInfoIcon text-white">
                                <i class="bi bi-calendar2-week-fill"></i>
                             </div>
                             <div>
                                <strong class="text-secondary">Moc</strong>
                                <p>power</p>
                            </div>
                        </div>
                    </div>
                </section>
                <section>
                    <h4 class="text-center">Opis:</h4>
                    <p>description</p>
                   </section>
                   <section class="productData">
                    <h4 class="text-center">Pozostałe dane:</h4>
                        <table>
                            <tr><td>data1</td><td>data2</td></tr>
                        </table>
                </section>
            </section>				
        </article>
    </main>
</template>

<script setup>
    
</script>

<style scoped>
#advertisementInfo > section
{
	grid-template-columns: minmax(0, 2.5fr) minmax(250px, 1fr);
	grid-auto-flow: dense;
	gap: 1rem;
	margin-top: -4rem;
}
#advertisementInfo > section > section
{
	border-radius: .5rem;
	background-color: white;
	box-shadow: 0 .25rem .5rem .125rem rgb(0 0 0 / .15);
	word-break: break-all;
	padding: .75rem;
}
#advertisementInfo > section > section:first-child
{
	grid-column: 2;
	grid-row: 1 / 6;
	height: fit-content;
	min-height: 8rem;
	gap: .5rem;
	position: sticky;
	word-break: initial;
	top: 6rem;
}
@media(max-width: 768px)
{
	#advertisementInfo > section
	{
		grid-template-columns: 1fr;
	}
	#advertisementInfo > section > section:first-child
	{
		position: fixed;
		top: auto;
		bottom: 0;
		width: 100%;
		grid-column: 1;
		margin-left: -.75rem;
	}
	#offerBody footer
	{
		margin-bottom: 8rem;
	}
}
.productData table
{
    width: 100%;
}
.productData table  tr:nth-of-type(even)
{
    background-color: rgb(195, 195, 195);
}
.productData table th, .productData table td
{
    width: 50%;
    height: 50px;
}
.productData tr > td:first-of-type, .productData tr > th:first-of-type
{
    text-align: right;
    padding-right: 5%;
}
.productData tr > td:last-of-type, .productData tr > th:last-of-type
{
    text-align: left;
}
</style>