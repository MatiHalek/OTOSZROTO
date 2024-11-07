import { mount } from '@vue/test-utils';
import UserProfile from '../pages/profil/index.vue';

describe('UserProfile.vue - Imię i Nazwisko input tests', () => {

    describe('Imię input field', () => {      
        it('should update Imię input field when user types', async () => {
            const wrapper = mount(UserProfile, {
                global: {
                    mocks: {
                        useUserStore: () => ({
                            name: '',
                            surname: '',
                            email: 'test@example.com',
                            phone: '123456789',
                        }),
                    },
                },
            });

            const nameInput = wrapper.find('input[placeholder="Imię"]');

            await nameInput.setValue('Jan');

            expect(nameInput.element.value).toBe('Jan');
        });
    });

    describe('Nazwisko input field', () => {
        it('should update Nazwisko input field when user types', async () => {
            const wrapper = mount(UserProfile, {
                global: {
                    mocks: {
                        useUserStore: () => ({
                            name: '',
                            surname: '',
                            email: 'test@example.com',
                            phone: '123456789',
                        }),
                    },
                },
            });

            const surnameInput = wrapper.find('input[placeholder="Nazwisko"]');

            await surnameInput.setValue('Kowalski');

            expect(surnameInput.element.value).toBe('Kowalski');
        });
    });
});
